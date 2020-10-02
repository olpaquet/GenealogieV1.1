create view VMessageRecu
AS
select 
c.id, c.date, c.sujet, c.texte, idemetteur, md.iddestinataire, 
md.datelecture, md.dateeffacement 
from conversation c
join messagedestination md on md.idconversation = c.id
