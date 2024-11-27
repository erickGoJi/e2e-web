USE e2e;

CREATE TABLE
	dbo.Areas (
		AreaID UNIQUEIDENTIFIER PRIMARY KEY,
		AreaName VARCHAR(50) UNIQUE NOT NULL,
		AreaDescription VARCHAR(100) NULL
	);

CREATE TABLE
	dbo.Profiles (
		ProfileID UNIQUEIDENTIFIER PRIMARY KEY,
		ProfileName VARCHAR(50) UNIQUE NOT NULL,
		ProfileDescription VARCHAR(100) NULL
	);

CREATE TABLE
	dbo.Users (
		UserID UNIQUEIDENTIFIER PRIMARY KEY,
		EmployeeNumber VARCHAR(20) UNIQUE NOT NULL,
		FirstName VARCHAR(100) NOT NULL,
		LastName NCHAR(10) NOT NULL,
		Email VARCHAR(50) NOT NULL,
		PasswordHash VARCHAR(255) NOT NULL,
		AreaID UNIQUEIDENTIFIER NULL,
		ProfileID UNIQUEIDENTIFIER NOT NULL,
		Status BIT NOT NULL DEFAULT 1,
		FailedAttemps INT DEFAULT 0,
		LastPasswordUpdated DATETIME2 DEFAULT CURRENT_TIMESTAMP,
		CreatedAt DATETIME2 DEFAULT CURRENT_TIMESTAMP,
		UpdatedAt DATETIME2 DEFAULT CURRENT_TIMESTAMP,
		FOREIGN KEY (AreaID) REFERENCES Areas (AreaID),
		FOREIGN KEY (ProfileID) REFERENCES Profiles (ProfileID)
	);

GO
-- Trigger to automatically update 'UpdatedAt' on row update
CREATE TRIGGER TRG_UpdateTimestamp ON dbo.Users AFTER
UPDATE AS BEGIN
UPDATE dbo.Users
SET
	UpdatedAt = CURRENT_TIMESTAMP
FROM
	dbo.Users AS U
	INNER JOIN inserted AS i ON U.UserID = i.UserID;

END;

GO GO
INSERT INTO
	dbo.Areas (AreaID, AreaName)
VALUES
	(NEWID (), 'Base de datos'),
	(NEWID (), 'Contact management'),
	(NEWID (), 'Soporte'),
	(NEWID (), 'Infraestructura'),
	(NEWID (), 'SI'),
	(NEWID (), 'Desarrollo'),
	(NEWID (), 'VoIP'),
	(NEWID (), 'IT'),
	(NEWID (), 'Recluta'),
	(NEWID (), 'Training'),
	(NEWID (), 'ADP'),
	(NEWID (), 'RH'),
	(NEWID (), 'Compras'),
	(NEWID (), 'Activo fijo'),
	(NEWID (), 'Legal'),
	(NEWID (), 'Admin'),
	(NEWID (), 'Calidad'),
	(NEWID (), 'MIS/BI'),
	(NEWID (), 'WFM'),
	(NEWID (), 'Finanzas'),
	(NEWID (), 'Dirección general');

GO GO
INSERT INTO
	dbo.Profiles (ProfileID, ProfileName)
VALUES
	(NEWID (), 'Comercial'),
	(NEWID (), 'Implementación'),
	(NEWID (), 'Validador'),
	(NEWID (), 'Operaciones');

GO GO
-- Table for Campaigns types
CREATE TABLE
	dbo.CampaignTypes (
		CampaignTypeID UNIQUEIDENTIFIER PRIMARY KEY,
		CampaignTypeName VARCHAR(100) NOT NULL,
		CampaignTypeDescription VARCHAR(100) NULL
	);

INSERT INTO
	dbo.CampaignTypes (CampaignTypeID, CampaignTypeName)
VALUES
	(NEWSEQUENTIALID (), 'Ventas'),
	(NEWSEQUENTIALID (), 'ATC'),
	(NEWSEQUENTIALID (), 'Cobnranza'),
	(NEWSEQUENTIALID (), 'Otro');

-- Table for Products and Services
CREATE TABLE
	dbo.ProductsServices (
		ProductServiceID UNIQUEIDENTIFIER PRIMARY KEY,
		ProductServiceName VARCHAR(100) NOT NULL,
		ProductServiceDescription VARCHAR(100) NULL
	);

INSERT INTO
	dbo.ProductsServices (ProductServiceID, ProductServiceName)
VALUES
	(NEWID (), 'Producto'),
	(NEWID (), 'Servicio');

-- Table for campaigns statuses
CREATE TABLE
	dbo.CampaignStatuses (
		CampaignStatusID UNIQUEIDENTIFIER PRIMARY KEY,
		CampaignStatusName VARCHAR(100) NOT NULL,
		CampaignStatusDescription VARCHAR(100) NULL
	);

INSERT INTO
	dbo.CampaignStatuses (CampaignStatusID, CampaignStatusName)
VALUES
	(NEWID(), 'Campaña generada'),
	(NEWID(), 'Asignación staff comercial / dir. Ops'),
	(NEWID(), 'Levantamiento comercial'),
	(NEWID(), 'Propuesta comercial'),
	(NEWID(), 'Respuesta comercial cliente'),
	(NEWID(), 'Campaña eliminada'),
	(NEWID(), 'Asignación staff implementación'),
	(NEWID(), 'Alcance implementación'),
	(NEWID(), 'Ejecución implementación'),
	(NEWID(), 'Campaña pausada'),
	(NEWID(), 'Campaña reactivada'),
	(NEWID(), 'Ejecución implementación reactivada'),
	(NEWID(), 'Pruebas'),
	(NEWID(), 'GoLive'),
	(NEWID(), 'Ongoing'),
	(NEWID(), 'Campaña completada');


-- Table for campaigns
CREATE TABLE
	dbo.Campaigns (
		CampaignID UNIQUEIDENTIFIER PRIMARY KEY,
		ClientName VARCHAR(100) NOT NULL,
		CampaignTypeID UNIQUEIDENTIFIER NOT NULL,
		ProductServiceID UNIQUEIDENTIFIER NOT NULL,
		StatusID UNIQUEIDENTIFIER NOT NULL,
		CreatedAt DATETIME2 DEFAULT CURRENT_TIMESTAMP,
		UpdatedAt DATETIME2 DEFAULT CURRENT_TIMESTAMP,
		FOREIGN KEY (CampaignTypeID) REFERENCES CampaignTypes (CampaignTypeID),
		FOREIGN KEY (ProductServiceID) REFERENCES ProductsServices (ProductServiceID),
		FOREIGN KEY (StatusID) REFERENCES CampaignStatuses (CampaignStatusID)
	);

INSERT INTO
	dbo.Campaigns (CampaignID, ClientName, CampaignTypeID, ProductServiceID, StatusID)
VALUES
	(NEWID(), 'Cliente 1', '421679A4-501C-4D19-9CD1-DEAD6AB6DC67', '02B3C6FC-9EF6-4D3D-ABEA-C4D5F7C8F156', 'A830FC35-DF31-4439-9C8E-85984E712952'),
	(NEWID(), 'Cliente 2', 'BEF24BC0-3E39-466F-AF65-AE074614DB62', 'F8BA3197-25F6-42F4-8701-66663B76111C', 'A830FC35-DF31-4439-9C8E-85984E712952'),
	(NEWID(), 'Cliente 3', 'CCECAB63-E515-4189-9E9C-5E21364EDB5C', '02B3C6FC-9EF6-4D3D-ABEA-C4D5F7C8F156', 'A830FC35-DF31-4439-9C8E-85984E712952'),
	(NEWID(), 'Cliente 4', '51B7B2AB-1F7C-4CBC-B136-5132F424D66D', 'F8BA3197-25F6-42F4-8701-66663B76111C', 'A830FC35-DF31-4439-9C8E-85984E712952');

-- Trigger to automatically update 'UpdatedAt' on row update
CREATE TRIGGER TRG_UpdateTimestamp_On_Campaigns ON dbo.Campaigns AFTER
UPDATE AS BEGIN
UPDATE dbo.Campaigns
SET
	UpdatedAt = CURRENT_TIMESTAMP
FROM
	dbo.Campaigns AS C
	INNER JOIN inserted AS i ON C.CampaignID = i.CampaignID;

END;

GO GO CREATE TRIGGER TRG_UpdateTimestamp_On_Campaigns ON dbo.Campaigns AFTER
UPDATE AS BEGIN
UPDATE dbo.Campaigns
SET
	UpdatedAt = CURRENT_TIMESTAMP
FROM
	dbo.Campaigns AS C
	INNER JOIN inserted AS i ON C.CampaignID = i.CampaignID;

END;

GO

-- Create Master Document
CREATE TABLE MasterDocument (
	DocumentId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	CampaignID UNIQUEIDENTIFIER NOT NULL,
	DocumentStatus NVARCHAR(100) NOT NULL,
	FOREIGN KEY (CampaignID) REFERENCES Campaigns(CampaignID)
);
-- Create Master Document Table (1:1 Relationship with Campaigns)
CREATE TABLE MasterDocument (
    CampaignID UNIQUEIDENTIFIER PRIMARY KEY,  -- Misma clave primaria que Campaigns
    DocumentStatus NVARCHAR(100) NOT NULL,
    FOREIGN KEY (CampaignID) REFERENCES Campaigns(CampaignID)  -- Relación 1:1 con Campaigns
);

INSERT INTO 
	MasterDocument (CampaignID, DocumentStatus)
VALUES 
('53D0C38-762C-4DD6-B436-9B9E609D6D29', 'Activo'),
('C93D45E-5C60-4345-96A5-9DE70CDBA223', 'Activo'),
('4B0B13B-6CE9-4A4C-B6AC-DC9ADF04B0EF', 'Activo'),
('9030D2E-81A6-4192-B8CA-E9F953D3C4B2', 'Activo'),

-- Table: Areas
CREATE TABLE Areas (
    AreaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    AreaName NVARCHAR(100) NOT NULL
);

-- Table: Titles (Concepts)
CREATE TABLE Titles (
    TitleId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    AreaId UNIQUEIDENTIFIER NOT NULL,
    TitleName NVARCHAR(100) NOT NULL,
    FOREIGN KEY (AreaId) REFERENCES Areas(AreaId)
);

-- Table: Participants
CREATE TABLE Participants (
    ParticipantId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    ParticipantName NVARCHAR(100) NOT NULL
);

-- Table: ParticipantDetails (Details for each participant by title with JSON)
CREATE TABLE ParticipantDetails (
	DetailId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	CampaignID UNIQUEIDENTIFIER NOT NULL,

	ParticipantName NVARCHAR(100) NOT NULL,
	ParticipantSectionName NVARCHAR(100) NOT NULL,
	AreaName NVARCHAR(100) NOT NULL,
	TitleName NVARCHAR(100) NOT NULL,

	FieldName NVARCHAR(100) NOT NULL,
	FieldValue NVARCHAR(MAX),  -- Stores JSON as a string
	FieldType NVARCHAR(100) NOT NULL,
	FOREIGN KEY (CampaignID) REFERENCES MasterDocument(CampaignID), 
);

DROP TABLE ParticipantDetails;
DROP TABLE Participants;
DROP TABLE Titles;
DROP TABLE DocumentAreas;

-- Table: Channels
CREATE TABLE Channels (
    ChannelId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    ChannelName NVARCHAR(100) NOT NULL
);

-- Table: TitleChannels (Relationship between titles and channels)
CREATE TABLE TitleChannels (
    TitleId UNIQUEIDENTIFIER NOT NULL,
    ChannelId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (TitleId) REFERENCES Titles(TitleId),
    FOREIGN KEY (ChannelId) REFERENCES Channels(ChannelId),
    PRIMARY KEY (TitleId, ChannelId)
);
