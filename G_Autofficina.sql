USE GestioneAutofficina;
DROP TABLE IF EXISTS Cliente;

--DDL
DROP TABLE IF EXISTS cliente;
DROP TABLE IF EXISTS veicolo;
CREATE TABLE Cliente (
						clienteID INTEGER PRIMARY KEY IDENTITY(1,1),
						codCliente VARCHAR(250) NOT NULL,
						nome VARCHAR(250) NOT NULL,
						cognome VARCHAR(250) NOT NULL,
						indirizzo VARCHAR(250) NOT NULL,
						telefono VARCHAR(16) NOT NULL UNIQUE,
						email VARCHAR(250) NOT NULL
						);
CREATE TABLE Veicolo (
						veicoloID INTEGER PRIMARY KEY IDENTITY(1,1),
						codVeicolo VARCHAR(250) NOT NULL,
						targa VARCHAR(16) NOT NULL,
						marca VARCHAR(100) NOT NULL,
						annoImm DATE NOT NULL,
						pIntervento DECIMAL NOT NULL,
						stato VARCHAR(250) NOT NULL CHECK(stato in ('in corso','completato','da fare')),
						dataIni DATE NOT NULL,
						UNIQUE(targa, marca),
						clienteRif INTEGER NOT NULL,
						FOREIGN KEY(clienteRif) REFERENCES Cliente(clienteID) ON DELETE CASCADE
						);


--DML

-- DML per la tabella Cliente
INSERT INTO Cliente (codCliente, nome, cognome, indirizzo, telefono, email) VALUES
('9fda8a0a-9db4-4f7c-bb5f-7282c6e1b105', 'Luca', 'Rossi', 'Via Roma 1, Milano', '3456789012', 'l.rossi@example.com'),
('fa7de90c-5b3f-4b0d-814b-1c44b5f57d91', 'Marco', 'Bianchi', 'Via Torino 4, Torino', '3351234567', 'm.bianchi@example.com'),
('e6135ef1-35b9-4c1b-933b-0e5ae04c872a', 'Giulia', 'Verdi', 'Corso Italia 15, Napoli', '3279876543', 'g.verdi@example.com'),
('a35efc11-df89-40d1-82b7-070b0cabb889', 'Francesca', 'Esposito', 'Piazza Garibaldi 12, Palermo', '3201239874', 'f.esposito@example.com'),
('f23f6ab0-b939-41b4-80d1-09ec0fd5e7cd', 'Davide', 'Ferrari', 'Via Dante 8, Firenze', '3298765432', 'd.ferrari@example.com'),
('b7c8e53f-fbbb-44da-8724-760c3261d314', 'Alessandro', 'Russo', 'Via Manzoni 9, Genova', '3345671234', 'a.russo@example.com'),
('705e21cf-d973-4676-813f-fb356ef78783', 'Martina', 'Gallo', 'Via Garibaldi 6, Bologna', '3387654321', 'm.gallo@example.com'),
('4b66d39b-f05d-4b59-9614-c9df13a2c5cb', 'Stefano', 'Ricci', 'Via Mazzini 10, Verona', '3312345678', 's.ricci@example.com'),
('52c8b660-d53b-4f90-97f4-2782f7b9d1fa', 'Sara', 'Marini', 'Via Napoli 7, Bari', '3209876543', 's.marini@example.com'),
('3b6c506b-05ea-42eb-b78a-57a671c18cae', 'Giorgio', 'Bruno', 'Via Veneto 3, Venezia', '3286543210', 'g.bruno@example.com');

-- DML per la tabella Veicolo
-- DML per la tabella Veicolo con 30 veicoli distribuiti non omogeneamente tra i clienti
INSERT INTO Veicolo (codVeicolo, targa, marca, annoImm, pIntervento, stato, dataIni, clienteRif) VALUES
('f8bc7f9e-6b82-4c9e-9872-9247bbf841b4', 'AA123BB', 'Fiat', '2021-03-15', 350.00, 'in corso', '2024-01-01', 1),
('26f3f9a5-1aeb-4b14-91f0-75977b06b5f4', 'CC456DD', 'BMW', '2019-07-20', 500.00, 'completato', '2023-12-20', 1),
('abb3b9e7-b61f-4a1d-8f76-e4f96c34a95e', 'EE789FF', 'Audi', '2020-05-10', 400.00, 'in corso', '2024-01-02', 2),
('e535b0e6-53cf-4f5e-80f6-6c4a1fc621c8', 'GG111HH', 'Volkswagen', '2018-09-18', 300.00, 'da fare', '2024-02-01', 2),
('a69f2b84-0469-4f8a-89fc-667d3adab30b', 'II222JJ', 'Mercedes', '2022-01-25', 600.00, 'completato', '2023-11-10', 3),
('d08a49da-9640-4935-9bc1-637d6c5cfabc', 'KK333LL', 'Renault', '2017-06-30', 250.00, 'da fare', '2024-01-15', 3),
('67d9c4e1-2918-44cf-b103-4a1d0c0289fa', 'MM444NN', 'Peugeot', '2021-04-22', 380.00, 'in corso', '2024-02-15', 4),
('8710f5e3-2f0b-495f-9f3e-012bc3a37e24', 'OO555PP', 'Toyota', '2020-11-15', 320.00, 'completato', '2023-10-12', 4),
('412db28d-bc6b-49b1-bf28-7d44ef70a517', 'QQ666RR', 'Ford', '2019-08-12', 450.00, 'da fare', '2024-03-01', 4),
('c93ad7b7-374e-4d1e-9154-c58d2b9f0f16', 'SS777TT', 'Tesla', '2023-02-14', 800.00, 'in corso', '2024-01-25', 5),
('18e26c4e-1b11-4d90-97be-79e339dd4d7f', 'UU888VV', 'Honda', '2017-12-05', 260.00, 'completato', '2023-09-25', 6),
('49a6764b-f70f-4ec3-a1d5-c69a514f8ed6', 'WW999XX', 'Hyundai', '2020-07-22', 370.00, 'da fare', '2024-02-10', 7),
('7621f764-cf87-4fbf-a518-62184ed58f78', 'YY000ZZ', 'Nissan', '2018-05-19', 290.00, 'in corso', '2024-01-30', 8),
('de4dbb6f-d92d-453d-b245-8a16f55a5c91', 'AB123CD', 'Kia', '2021-10-08', 310.00, 'completato', '2023-12-15', 8),
('05917a28-f8ba-49a6-ae72-f567db9f23a7', 'EF456GH', 'Citroen', '2016-03-22', 240.00, 'in corso', '2024-01-18', 8),
('12341b1d-60b6-47de-b70f-c48fc10b7f35', 'IJ789KL', 'Suzuki', '2019-06-11', 400.00, 'da fare', '2024-02-05', 9),
('9e7e1b5d-0f9b-46f2-a14e-cb6bcd1e541b', 'MN012OP', 'Mitsubishi', '2021-01-30', 370.00, 'completato', '2023-11-01', 9),
('32b4129f-3d98-45f5-b63a-0b6629a11b4b', 'QR345ST', 'Mazda', '2018-11-25', 280.00, 'in corso', '2024-01-05', 10),
('4e292fd4-e4fc-44b3-8d43-3cc6f3d6a9e3', 'UV678WX', 'Jaguar', '2022-04-17', 520.00, 'completato', '2023-10-20', 5),
('0e5836ba-8898-47ef-a1f0-3db5f28e4095', 'YZ901AB', 'Alfa Romeo', '2020-09-05', 480.00, 'in corso', '2024-01-20', 6),
('bb45c4d8-501d-41d1-9028-f07c11c7386e', 'CD234EF', 'Chevrolet', '2021-12-10', 450.00, 'completato', '2023-11-15', 7),
('7c3a7028-2bb9-4a9f-a104-35364d649cfc', 'GH567IJ', 'Lexus', '2019-03-13', 530.00, 'in corso', '2024-01-25', 10),
('76e1b10c-b798-4911-ae5c-501d302f3c23', 'KL890MN', 'Dacia', '2020-08-27', 280.00, 'da fare', '2024-02-18', 3),
('f82b2b97-fd70-47b6-a14d-e08ab5b1a1d5', 'OP123QR', 'Opel', '2017-11-03', 350.00, 'completato', '2023-09-15', 2),
('10db1df2-1c83-4f13-93a2-99f8c4e21b6b', 'ST456UV', 'Subaru', '2019-05-21', 420.00, 'in corso', '2024-01-10', 3),
('612f42d3-1d77-4dd2-a137-f889a79e53d5', 'WX789YZ', 'Volvo', '2020-07-09', 510.00, 'da fare', '2024-02-25', 6),
('d0b85902-0d91-4f3a-8608-2c5a4a8b7ed9', 'AA890BB', 'Skoda', '2021-06-18', 360.00, 'completato', '2023-10-18', 1),
('0fe3ac6d-925e-46ac-8b43-091308594dcb', 'CC123DD', 'Ferrari', '2022-09-23', 920.00, 'in corso', '2024-02-05', 10),
('2123ef69-4a80-44d2-900e-656ec1c9a120', 'EE456FF', 'Lamborghini', '2020-04-04', 950.00, 'completato', '2023-12-05', 5),
('aa87091a-b7b5-4740-86d4-171d8e718255', 'FF678GG', 'Maserati', '2021-02-20', 980.00, 'in corso', '2024-01-15', 7);




--QL 
SELECT * FROM Cliente;
SELECT * FROM Veicolo;

SELECT * FROM Cliente
		JOIN Veicolo ON Cliente.clienteID = Veicolo.clienteRif

