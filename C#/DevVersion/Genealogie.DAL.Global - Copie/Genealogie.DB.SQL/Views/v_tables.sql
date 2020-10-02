CREATE view v_tables as
select 
--distinct type_desc
o.name nomtable, 
c.column_id idcol,
c.name nomcol,
t.name typecol,
c.max_length longueurmax, c.precision, c.scale, c.is_nullable estnullable
from sys.all_objects o join sys.all_columns c on o.object_id = c.object_id join sys.types t on c.user_type_id = t.user_type_id
where o.type_desc = 'USER_TABLE'
and o.schema_id = 1
--order by o.name, c.column_id

