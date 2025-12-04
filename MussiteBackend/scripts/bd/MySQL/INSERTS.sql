
USE 5to_mussitedatabase;

INSERT INTO Usuario (Nombre, Email, Contrasena, perfilUrl, bannerUrl)
VALUES ('softeraser','softeraser@gmail.com','soft123','/uploads/avatars/softeraser.png', '/uploads/banners/bajobanner.jpg');

INSERT INTO Partitura (IdUsuario, Titulo, ImagenUrl, PDFUrl, Compositor)
VALUES
(1, 'Milonga del solitario', '/uploads/partituras/img/solitario.png', '/uploads/partituras/pdf/solitario.pdf', 'Atahualpa Yupanqui'),

(1, 'Choro da Saudade', '/uploads/partituras/img/choro.png', '/uploads/partituras/pdf/choro.pdf', 'Agustin Barrios'),

(1, 'Sonata 23', '/uploads/partituras/img/Carlos Seixas Sonata 23.png', '/uploads/partituras/pdf/SeixasCarlos-Sonata23-24.pdf', 'Carlos Seixas'),

(1, 'Waltz Op. 64 No.2', '/uploads/partituras/img/op64-2.jpeg', '/uploads/partituras/pdf/op64-2.pdf', 'Chopin'),

(1, 'Waltz Op. 69 No.1', '/uploads/partituras/img/op69-1.png', '/uploads/partituras/pdf/op69-1.pdf', 'Chopin'),

(1, 'Waltz Op. 34 No. 2', '/uploads/partituras/img/op34-2.png', '/uploads/partituras/pdf/op34-2.pdf', 'Chopin'),

(1, 'Noctuner Op. 72 No. 1', '/uploads/partituras/img/op72-1.png', '/uploads/partituras/pdf/op72-1.pdf', 'Chopin'),

(1, 'Ballade Op. 23 No. 1', '/uploads/partituras/img/balade-1.png', '/uploads/partituras/pdf/balade-1.pdf', 'Chopin'),

(1, 'Hungarian Rhapsody No. 2', '/uploads/partituras/img/hungarian-2.png', '/uploads/partituras/pdf/hungarian-2.pdf', 'Franz Liszt'),

(1, 'Barcarola Op. 202 ''Mallorca''', '/uploads/partituras/img/mallorca.png', '/uploads/partituras/pdf/mallorca.pdf', 'Isaac Albeniz'),

(1, 'Etude Op. 76 No. 2', '/uploads/partituras/img/mallorca.png', '/uploads/partituras/pdf/mallorca.pdf', 'Jean Sibelius'),

(1, 'Liebeslied (Love''s Sorrow)', '/uploads/partituras/img/liebeslied.png', '/uploads/partituras/pdf/liebeslied.pdf', 'Sergei Rachmaninoff'),

(1, 'Vals Venezolano No. 2 ''Andreina''', '/uploads/partituras/img/andreina.png', '/uploads/partituras/pdf/andreina.pdf', 'Antonio Lauro'),

(1, 'Vals Venezolano No. 3 ''Natalia''', '/uploads/partituras/img/natalia.png', '/uploads/partituras/pdf/natalia.pdf', 'Antonio Lauro'),

(1, 'Vals Venezolano No. 5 ''Carora''', '/uploads/partituras/img/carora.png', '/uploads/partituras/pdf/carora.pdf', 'Antonio Lauro'),

(1, 'Serenata Española', '/uploads/partituras/img/serenata.png', '/uploads/partituras/pdf/serenata.pdf', 'Joaquín Malats');
