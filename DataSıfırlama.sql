-- T�m verileri sil
DELETE FROM Tarifler;
-- ID'leri s�f�rlama
DBCC CHECKIDENT ('Tarifler', RESEED, 0);
-- T�m verileri sil
DELETE FROM Malzemeler;
-- ID'leri s�f�rlama
DBCC CHECKIDENT ('Malzemeler', RESEED, 0);
-- T�m verileri sil
DELETE FROM TarifMalzeme;
-- ID'leri s�f�rlama
DBCC CHECKIDENT ('TarifMalzeme', RESEED, 0);