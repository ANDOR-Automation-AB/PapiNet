# PapiNet.WoodX

Detta �r en open-source implementation av PapiNet WoodX enligt specifikationen i 
Implementation Guide V2.31. Detta projekt �r inte en officiell implementation fr�n PapiNet.

---

## DeliveryMessage

### Avvikelser

#### ShipToInformation
Enligt papiNet WoodX standarden ska ShipToInformation vara en grupp (group element)
som inneh�ller information om mottagaren och leveransvillkoren. 
I den aktuella implementationen har ShipToInformation ist�llet lagts som ett 
enskilt element, vilket avviker fr�n standarden. F�r att s�kerst�lla kompatibilitet
och korrekt struktur enligt standarden b�r ShipToInformation omstruktureras till 
en grupp som inneh�ller ShipToCharacteristics, ShipToParty, 
och eventuellt TermsOfDelivery.

#### SafetyAndEnvironmentalType
Enligt papiNet WoodX standarden �r SafetyAndEnvironmentalType ett 
obligatoriskt element som ska inkluderas i varje DeliveryShipmentLineItem. 
Detta element anv�nds f�r att kommunicera viktig s�kerhets- och 
milj�relaterad information.
I den aktuella implementationen saknas SafetyAndEnvironmentalType, vilket 
avviker fr�n standarden. F�r att s�kerst�lla fullst�ndig kompatibilitet 
b�r detta element implementeras enligt specifikationen.

---

Copyright (c) 2000-2024 papiNet SNC. All rights reserved. 
Detta projekt �r baserat p� den �ppna PapiNet WoodX standarden.
