import RPi.GPIO as GPIO
from mfrc522 import SimpleMFRC522
import time

leitorRfid = SimpleMFRC522()

def doLogin():
    print("Aproxime o cartao da leitora rfid...")
    try:
            id, text = leitorRfid.read()
            print("ID do cartao: ", id)
            if id == 291913269973:
                print("Tag RFID valida!")                
                time.sleep(2)
                return 1
            else:
                print("Tag RFID nao permitida!")
                time.sleep(2)
                return 0
            
    finally:
            return 0