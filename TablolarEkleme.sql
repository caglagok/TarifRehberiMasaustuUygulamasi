-- Tarifler Tablosu
CREATE TABLE Tarifler (
    TarifID INT PRIMARY KEY IDENTITY(1,1),  -- IDENTITY ile otomatik artan birincil anahtar
    TarifAdi VARCHAR(255) NOT NULL,
    Kategori VARCHAR(100) NOT NULL,
    HazirlamaSuresi INT NOT NULL,
    Talimatlar TEXT
);

-- Malzemeler Tablosu
CREATE TABLE Malzemeler (
    MalzemeID INT PRIMARY KEY IDENTITY(1,1),  -- IDENTITY ile otomatik artan birincil anahtar
    MalzemeAdi VARCHAR(255) NOT NULL,
    ToplamMiktar VARCHAR(100),
    MalzemeBirim VARCHAR(50),
    BirimFiyat DECIMAL(10, 2)  -- Para birimi için DECIMAL kullanýmý
);

-- Tarif-Malzeme Ýliþkisi Tablosu
CREATE TABLE TarifMalzeme (
    TarifID INT,
    MalzemeID INT,
    MalzemeMiktar FLOAT NOT NULL,
    PRIMARY KEY (TarifID, MalzemeID),
    FOREIGN KEY (TarifID) REFERENCES Tarifler(TarifID) ON DELETE CASCADE,
    FOREIGN KEY (MalzemeID) REFERENCES Malzemeler(MalzemeID) ON DELETE CASCADE
);
