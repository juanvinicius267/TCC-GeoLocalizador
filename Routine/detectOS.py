import os
import platform
import json

def detect_OS():
    #Checando qual o sistema operacional
    system = str(platform.system())
    #Checando a versão
    version = str(platform.release())
    #Criando o JSON
    systemInfo = json.dumps({"system":system, "version": version})
    #retornando resultados obtidos
    return systemInfo
