#Importando bibliotecas
#import pyserial

import json
from detectOS import detect_OS
from serialCommunication import *
from readTag import *
from readTemperature import *
#Campo das declarações de variaveis
tryTimes = 0

#region Setup inicial do programa

#Detecta qual sistema operacional
systemInfo = detect_OS()
#Formata o json com as informações do sistema operacional
system = json.loads(systemInfo)

#Seleciona a plataforma e realiza o setup indicado para aquela plataforma
while (tryTimes < 1):
    # Configura o modulo para ler posições geograficas
    statusGpsInitialSetup = selectPlataform(system['system'])
    # Convert o dado retornado para Json
    statusGpsInitial = json.loads(statusGpsInitialSetup)
    # Configura o modulo para realizar requisições HTTP/s
    setupConnHttp()
    # Verifica se a configuração está OK
    if statusGpsInitial["moduloStatus"] == 'OK' and statusGpsInitial["gnssStatus"] == 'OK' and statusGpsInitial["setFormatStatus"] == 'OK':   
        tryTimes = 6
        break
    if tryTimes > 5:
        # Caso fique em loop infinito, ele para a rotina
        raise Exception('Problemas na inicialização do modulo!')    
    
    tryTimes = tryTimes + 1
#endregion

# Antes de realizar a leitura dos dados, a rotina aguarda a leitura do cartão rfid de login do motorista
while True:
    if (doLogin() == 1):
        break

#region Main Program
while True:
    readTemp()
    # Realiza a leitura da localização
    localization = getGeoLocation()
    # Converte para Json o objeto retornado do metodo de leitura
    localization = json.loads(localization)
    # Imprime no terminal os dados retornados
    print(localization)
    # Envia os dados para o servidor via requisições HTTP/s
    getDataOnServer(localization["lat"], localization["lon"], localization["utcDateTime"], localization["altitude"], 
    localization["velocidade"], localization["courseOverGround"] ,localization["fixMode"], localization["runStatus"],
    localization["gnssSatellitiesUsed"], localization["glonasSatelittiesUsed"])    

#endregion

