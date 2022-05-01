import json

def geoLocationFormatter(runStatus, fixStatus, utcDateTime, latitude, longitude,
altitude, velocidade, courseOverGround, fixMode, hdop, pdop, vdop, gnssSatelittiesInView, gnssSatellitiesUsed,
glonasSatelittiesUsed, cn0max, hpa, vpa):
    return json.dumps({
        "runStatus": '1',#runStatus,
        "fixStatus": fixStatus,
        "utcDateTime": utcDateTime,
        "lat": latitude,
        "lon": longitude,
        "altitude": altitude,
        "velocidade": velocidade,
        "courseOverGround": courseOverGround,
        "fixMode": fixMode,
        "hdop": hdop,
        "pdop": pdop,
        "vdop": vdop,
        "gnssSatelittiesInView": gnssSatelittiesInView,
        "gnssSatellitiesUsed": gnssSatellitiesUsed,
        "glonasSatelittiesUsed": glonasSatelittiesUsed,
        "cn0max": cn0max,
        "hpa": hpa,
        "vpa": vpa
    })