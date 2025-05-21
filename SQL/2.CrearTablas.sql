use Transferencia
go

if  exists (select * from sys.tables where name = 'Movimiento')
begin 
	drop table Billetera
end
go 

if  exists (select * from sys.tables where name = 'Billetera')
begin 
	drop table Billetera
end
go 

create table Billetera 
(
Id int identity(1,1),
DocumentId varchar(20),
Name varchar(100),
Balance decimal(19,2),
CreateAt datetime,
UpdateAt datetime,
Primary Key(Id)
)
go

EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Identificador unico, numero entero autoincrmental', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Billetera',    @level2type = N'COLUMN', @level2name = 'Id';
go 
EXEC sp_addextendedproperty @name = N'MS_Description',  @value = '"Documento de identidad de la persona propietaria de la billetera', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Billetera',    @level2type = N'COLUMN', @level2name = 'DocumentId';
go 
EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Nombre del propietario de la billetera', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Billetera',    @level2type = N'COLUMN', @level2name = 'Name';
go 
EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Saldo de la billetera', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Billetera',    @level2type = N'COLUMN', @level2name = 'Balance';
go 
EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Fecha de Apertura de la billetera', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Billetera',    @level2type = N'COLUMN', @level2name = 'CreateAt';
go 
EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Fecha de ultima actualizacion de la billetera', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Billetera',    @level2type = N'COLUMN', @level2name = 'UpdateAt';
go 

create table Movimiento 
(
Id int identity(1,1),
WalletId int,
Amount decimal(19,2),
Type varchar(20),
CreateAt datetime,
Primary Key(Id),
FOREIGN KEY (WalletId) REFERENCES Billetera(Id)
)
go

EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Identificador unico del movimiento', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Movimiento',    @level2type = N'COLUMN', @level2name = 'Id';
go 
EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Identificador de la billetera', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Movimiento',    @level2type = N'COLUMN', @level2name = 'WalletId';
go 
EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Monto de la transaccion', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Movimiento',    @level2type = N'COLUMN', @level2name = 'Amount';
go 
EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Tipo de Transaccion Debito/Credito', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Movimiento',    @level2type = N'COLUMN', @level2name = 'Type';
go 
EXEC sp_addextendedproperty @name = N'MS_Description',  @value = 'Fecha de la transaccion', @level0type = N'SCHEMA', @level0name = 'dbo',    @level1type = N'TABLE',  @level1name = 'Movimiento',    @level2type = N'COLUMN', @level2name = 'CreateAt';
go 