# PapiNet Standard

Detta är en open-source implementation av papiNet WoodX enligt specifikationen i 
Implementation Guide V2.31. Detta projekt är inte en officiell implementation från PapiNet.

**Referensdokument papiNet V2R31**
https://www.papinet.org/fileadmin/user_upload/v2r31/20091201/DataDictV2R31_20091201-2010-01-28.pdf

---

## DeliveryMessage

### Avvikelser

#### ShipToInformation
Enligt papiNet WoodX standarden ska ShipToInformation vara en grupp (group element)
som innehåller information om mottagaren och leveransvillkoren. 
I den aktuella implementationen har ShipToInformation istället lagts som ett 
enskilt element, vilket avviker från standarden. För att säkerställa kompatibilitet
och korrekt struktur enligt standarden bör ShipToInformation omstruktureras till 
en grupp som innehåller ShipToCharacteristics, ShipToParty, 
och eventuellt TermsOfDelivery.

#### SafetyAndEnvironmentalType
Enligt papiNet WoodX standarden är SafetyAndEnvironmentalType ett 
obligatoriskt element som ska inkluderas i varje DeliveryShipmentLineItem. 
Detta element används för att kommunicera viktig säkerhets- och 
miljörelaterad information.
I den aktuella implementationen saknas SafetyAndEnvironmentalType, vilket 
avviker från standarden. För att säkerställa fullständig kompatibilitet 
bör detta element implementeras enligt specifikationen.

---

Copyright (c) 2000-2024 papiNet SNC. All rights reserved. 
Detta projekt är baserat på den öppna PapiNet WoodX standarden.
