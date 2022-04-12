#Importando bibliotecas
#import pyserial

import json
from detectOS import detect_OS
from serialCommunication import *

#Campo das declarações de variaveis
tryTimes = 0

#region Setup inicial do programa

#Detecta qual sistema operacional
systemInfo = detect_OS()
#Formata o json com as informações do sistema operacional
system = json.loads(systemInfo)
#Seleciona a plataforma e realiza o setup indicado para aquela plataforma
#region Main Program


    
    




#endregion

while (tryTimes < 1):
    #
    statusGpsInitialSetup = selectPlataform(system['system'])
    #
    statusGpsInitial = json.loads(statusGpsInitialSetup)
    #
    #
    if statusGpsInitial["moduloStatus"] == 'OK' and statusGpsInitial["gnssStatus"] == 'OK' and statusGpsInitial["setFormatStatus"] == 'OK':   
        tryTimes = 6
        break
    if tryTimes > 5:
        #
        raise Exception('Problemas na inicialização do modulo!')
    
    #
    tryTimes = tryTimes + 1
#endregion

setupConnHttp()

while True:
    localization = getGeoLocation()
    localization = json.loads(localization)
    print(localization)
    getDataOnServer(localization["lat"], localization["lon"])
