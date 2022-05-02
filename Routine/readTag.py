import RPi.GPIO as GPIO
from mfrc522 import SimpleMFRC522
import time
from serialCommunication import sendTagDataToServer
leitorRfid = SimpleMFRC522()

result = 2
def doLogin():
    print("Aproxime o cartao da leitora rfid...")
    try:
            id, text = leitorRfid.read()
            print("ID do cartao: ", id)
            if id == 345847071554:
                print("Tag RFID valida!")                
                sendTagDataToServer(str(id),"Aprovado")
                result = 1
            else:
                print("Tag RFID não permitida!")
                sendTagDataToServer(str(id),"Recusado")
                time.sleep(2)
                result = 0
            
    finally:
            return result

