select * from Enderecos;
select * from Funcionarios;
select * from Viagens;
select * from Despesas;
select * from DespesasHospedagem;
select * from Enderecos;

delete from viagem;
delete from despesas;
delete from despesaHospedagem;
delete from endereco;

DBCC CHECKIDENT('viagem', RESEED, 0);
DBCC CHECKIDENT('despesas', RESEED, 0);
DBCC CHECKIDENT('DespesaHospedagem', RESEED, 0);
DBCC CHECKIDENT('endereco', RESEED, 0)

select * from DespesaHospedagem a inner join endereco b on a.id = b.id inner join despesas c on c.id = a.id


--insert into Viagem values ('Viagem 1', 'Primeira viagem', 2300, GETDATE(), DATEADD(day, 15, GETDATE()), 0, 'Aberta', 'Joao', '123456')
--insert into Viagem values ('Viagem 2', 'Segunda viagem', 2300, GETDATE(), DATEADD(day, 14, GETDATE()), 0, 'Aberta', 'Joao', '123456')
--insert into Despesas values ('Despesa 2', 'Segunda despesa', 250, GETDATE(), 'Hospedagem', 1)
--insert into DespesaHospedagem values (2, 15, 89)
--insert into Endereco values (2, 'Logradouro generico', 12, '123124', 'Guarulhos', 'SP')



