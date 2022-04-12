#Importação de bibliotecas
import serial
import time
from decimal import *
from dataFormatterStand import *

#Variaveis comuns ao Script
# Parametriza a como será a leitura na porta serial
serialPort = serial.Serial('COM4',baudrate=115200, timeout=1) # Windows
#serialPort = serial.Serial('/dev/ttyUSB0',baudrate=115200, timeout=1) # Linux

#Função que seleciona qual o setup para o sistema operacional que esta rodando
def selectPlataform(operationalSystem):
    if(operationalSystem == 'Windows'):
        return communicationForWindows(operationalSystem)
    else:
        return communicationForRaspbian(operationalSystem)

#Funcão para realizar a comunicação com o modulo GPS/GNSS
def doCommunication(command):
    #Convert o comando para String (Apenas para ter certeza que vira ua string)
    _command = str(command)
    #Codifica para binario o comando
    _encodeCommand = (_command +'\r\n').encode()
    #Escreve na porta serial o comando formatado
    serialPort.write(_encodeCommand)
    time.sleep(.2)
    #aguarda o retorno do modulo GPS/GNSS e quando ele terminar de enviar o dado, continua o programa
    dataReceived = serialPort.read(2000)
    #Decodifica o resultado do comando para uma string
    _dataReceivedDecoded = dataReceived.decode()    
    # Aguarda 200 milisegundos para continuar o programa
    time.sleep(.2)
    #Imprime no terminal
    print(str(_dataReceivedDecoded))
    # retorna o valor obitido no comando
    return str(_dataReceivedDecoded)

#region Funções do GPS/GNSS

#Função que realiza a parametrização da porta serial para o windows e faz o setup inicial do programa para a leitura
def communicationForWindows(operationalSystem):
    # Chama as funções e retorna o valor de retorno das chamadas
    return json.dumps({
        "os": operationalSystem,
        "serialPort":"COM4",
        "baudrate": 115200,
        "timeout": 1,
        "moduloStatus": doCommunication('AT'),             # Leitura do Status do Modulo
        "gnssStatus": doCommunication('AT+CGNSPWR=1'), # Comando para ligar o GPS/GNSS
        "setFormatStatus":doCommunication('AT+CGNSTST=0'), # Comando para receber na UART e indicar o formato que deve vir(0 - Dado vem formatado e 1 - Dado vem com todas as informações)
        "firstData": doCommunication('AT+CGNSINF')       # Realiza leitura no modulo
    })

#Função que realiza a parametrização da porta serial para o Raspbian e faz o setup inicial do programa para a leitura
def communicationForRaspbian(operationalSystem):
    # Chama as funções e retorna o valor de retorno das chamadas
    return json.dumps({
        "os": operationalSystem,
        "serialPort":"/dev/ttyS0",
        "baudrate": 115200,
        "timeout": 1,
        "moduloStatus": doCommunication('AT'),             # Leitura do Status do Modulo
        "gnssStatus": doCommunication('AT+CGNSPWR=1'), # Comando para ligar o GPS/GNSS
        "setFormatStatus":doCommunication('AT+CGNSTST=0'), # Comando para receber na UART e indicar o formato que deve vir(0 - Dado vem formatado e 1 - Dado vem com todas as informações)
        "firstData": doCommunication('AT+CGNSINF')       # Realiza leitura no modulo
    })

#Função para realizar a leitura ciclicamente dos dados do modulo GPS/GNSS
def getGeoLocation():
    #Chama função passando o comando de de leitura da localização
    geoLocationData = doCommunication('AT+CGNSINF')
    print(geoLocationData)
    #Separa o retorno da doComunicação e coloca em um Array
    arrayWithGeoLocationData = geoLocationData.split(",")       
    #Formata os dados no padrão
    return geoLocationFormatter(arrayWithGeoLocationData[0],arrayWithGeoLocationData[1],arrayWithGeoLocationData[2],arrayWithGeoLocationData[3],
    arrayWithGeoLocationData[4],arrayWithGeoLocationData[5],arrayWithGeoLocationData[6],arrayWithGeoLocationData[7],
    arrayWithGeoLocationData[8],arrayWithGeoLocationData[10],arrayWithGeoLocationData[11],
    arrayWithGeoLocationData[13],arrayWithGeoLocationData[14],arrayWithGeoLocationData[15],
    arrayWithGeoLocationData[17],arrayWithGeoLocationData[18],arrayWithGeoLocationData[19], "")
#endregion

#region Funções da comunicação do acesso a internet

def setupConnHttp():
    # Usado para ligar e configurar o trafego de dados - 1 -Open bearer, 1 - Bearer profile identifier
    doCommunication('AT+SAPBR=3,1,CONTYPE,GPRS')
    doCommunication('AT+SAPBR=3,1,APN,claro.com.br')
    doCommunication('AT+SAPBR=3,1,USER,claro')
    doCommunication('AT+SAPBR=3,1,PWD,claro')
    doCommunication('AT+SAPBR=1,1')
    doCommunication('AT+SAPBR=2,1')

def setDataOnServer():
    # Abrindo a requisição HTTP
    doCommunication('AT+HTTPINIT')
    # Comando de parametrização da requsição HTTP
    doCommunication('AT+HTTPPARA="CID",1')
    # Comando de parametrização da URL da requsição HTTP
    doCommunication('AT+HTTPPARA="URL","https://geo-localizador.azurewebsites.net/raspberry/set-data"')
    # Comando de parametrização do content type da requsição HTTP (tipagem de como vai ser enviado os dados)
    doCommunication('AT+HTTPPARA=CONTENT,application/x-www-urlencoded')
    # Comando de parametrização do tamanho da informação
    doCommunication('AT+HTTPDATA=307,1000')
    #Enviando o dado
    doCommunication('param=e-e-e-e')
    # Comando de parametrização do metodo HTTP que será usado - GET = 0 e POST = 1
    doCommunication('AT+HTTPACTION=1')
    # Comando de leitura do retorno da requisição
    doCommunication('AT+HTTPREAD=0,307')
    # Fechando a conexão
    doCommunication('AT+HTTPTERM')

def getDataOnServer(lon, lat):
    url = "http://geo-localizador.azurewebsites.net/raspberry/set-data-2?param="+lon+","+lat
    # Abrindo a requisição HTTP
    doCommunication('AT+HTTPINIT')
    # Comando de parametrização da requsição HTTP
    doCommunication('AT+HTTPPARA="CID",1')
    # Comando de parametrização da URL da requsição HTTP
    doCommunication('AT+HTTPPARA="URL","'+url+'"')    
    # Comando de parametrização do metodo HTTP que será usado - GET = 0 e POST = 1
    doCommunication('AT+HTTPACTION=0')
    # Comando de leitura do retorno da requisição
    #doCommunication('AT+HTTPREAD=0,5000')
    
    # Fechando a conexão
    doCommunication('AT+HTTPTERM')

#endregion



#region lista de comandos
# AT+SAPBR=3,1,CONTYPE,GPRS - OK
# AT+SAPBR=3,1,APN,claro.com.br - OK
# AT+SAPBR=3,1,USER,claro - OK
# AT+SAPBR=3,1,PWD,claro OK
# AT+SAPBR=1,1 - OK
# AT+SAPBR=2,1 - OK
# AT+HTTPINIT - OK
# AT+HTTPPARA="CID",1 - OK
# AT+HTTPPARA="URL","http://miliohm.com/miliohmSIM800L.php" - OK

# #PARA POST METHOD
# AT+HTTPPARA=CONTENT,application/x-www-urlencoded
# AT+HTTPDATA=192,10000
# params= data+ "-" + data 2(codigo)
# AT+HTTPACTION=1
# #END PARA POST METHOD

# AT+HTTPACTION=0
# AT+HTTPREAD=0,84
# AT+HTTPTERM - OK



# AT+CFUN=1
# AT+CPIN?
# AT+CSTT="claro.com.br","claro","claro"
# AT+CIICR
# AT+CIFSR
# AT+CIPSTART="TCP","exploreembedded.com",80
# AT+CIPSEND=63
# GET exploreembedded.com/wiki/images/1/15/Hello.txt HTTP/1.0
# AT+SAPBR=3,1,CONTYPE,GPRS
# AT+SAPBR=1,1
# AT+HTTPINIT
# AT+HTTPPARA="CID",1
# AT+HTTPPARA="URL","http://miliohm.com/miliohmSIM800L.php"
# AT+HTTPACTION=0
# at+httppara="URL","www.m2msupport.net/m2msupport/test.php"
# AT+CDGCONT=1,"IP","claro.com.br"

# AT+SAPBR=3,1,CONTYPE,GPRS - OK
# AT+SAPBR=3,1,APN,claro.com.br - OK
# AT+SAPBR=3,1,USER,claro - OK
# AT+SAPBR=3,1,PWD,claro OK
# AT+SAPBR=1,1 - OK
# AT+SAPBR=2,1 - OK
# AT+HTTPINIT - OK
# AT+HTTPPARA="CID",1 - OK
# AT+HTTPPARA="URL","http://miliohm.com/miliohmSIM800L.php" - OK

# #PARA POST METHOD
# AT+HTTPPARA=CONTENT,application/x-www-form-urlencoded
# AT+HTTPDATA=192,10000
# params= data+ "-" + data 2(codigo)
# AT+HTTPACTION=1
# #END PARA POST METHOD

# AT+HTTPACTION=0
# AT+HTTPREAD=0,84
# AT+HTTPTERM - OK

#TCP/IP https://www.youtube.com/watch?v=FN0694pR4Gk
# AT+CIPMODE=0
# AT+CIPMUX=0
# AT+CGATT=1
# AT+CREG?
# AT+CGATT?
# AT+CSTT="zap.vivo.com.br","vivo","vivo"
# AT+CIICR
# AT+CIFSR

# AT+CIPSTART="TCP","api.thingspeak.com","80"
# AT+CIPSEND=48

# GET /update?api_key=W1VFHL833HBN44JQ&field1=25
#endregion
