import RPi.GPIO as GPIO
import dht11
import json

# read data using pin 14
instance = dht11.DHT11(pin = 7)
def readTemp():
    result = instance.read()

    if result.is_valid():
        print("Temperature: %-3.1f C" % result.temperature)
        print("Humidity: %-3.1f %%" % result.humidity)
        temp = str(result.temperature)
        humid = str(result.humidity)
        return json.dumps({
            "temp":str(result.temperature),
            "humid":str(result.humidity)
        })
    else:
        print("Error: %d" % result.error_code)
