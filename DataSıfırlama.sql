-- Tüm verileri sil
DELETE FROM Tarifler;
-- ID'leri sýfýrlama
DBCC CHECKIDENT ('Tarifler', RESEED, 0);
-- Tüm verileri sil
DELETE FROM Malzemeler;
-- ID'leri sýfýrlama
DBCC CHECKIDENT ('Malzemeler', RESEED, 0);
-- Tüm verileri sil
DELETE FROM TarifMalzeme;
-- ID'leri sýfýrlama
DBCC CHECKIDENT ('TarifMalzeme', RESEED, 0);