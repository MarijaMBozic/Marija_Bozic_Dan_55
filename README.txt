Implementirano je slanje sms pomocu:
https://www.twilio.com/try-twilio

ali da biste to mogli da testirate potrebno je da se kod njih registrujete, 
odaberete broj telefona koji salje sms i verifikujete vas broj.
zatim je potrebno u mom kodu :
PanPizza.ViewsModel.OrderViewModel

u metodi : SendMessage


 const string accountSid = "" - uneste accountSid  koji ste od njih dobili prilikom regoistracije
 const string authToken = ""; uneste authToken koji ste od njih dobili prilikom regoistracije

from: new Twilio.Types.PhoneNumber("+17272611706")- i ovo polje unosite broj koji ste od njih "kupili" prilikom registracije.

