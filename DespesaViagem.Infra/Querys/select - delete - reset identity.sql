select * from Viagem;
select * from Despesas;
select * from DespesaHospedagem;
select * from Endereco;

delete from viagem;
delete from despesas;
delete from despesaHospedagem;
delete from endereco;

DBCC CHECKIDENT('viagem', RESEED, 0);
DBCC CHECKIDENT('despesas', RESEED, 0);
DBCC CHECKIDENT('DespesaHospedagem', RESEED, 0);
DBCC CHECKIDENT('endereco', RESEED, 0)

select * from DespesaHospedagem a inner join endereco b on a.id = b.id inner join despesas c on c.id = a.id


