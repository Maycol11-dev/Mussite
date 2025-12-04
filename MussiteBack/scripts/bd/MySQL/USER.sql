
DROP USER IF EXISTS 'admin'@'localhost';
CREATE USER 'admin'@'localhost' IDENTIFIED BY 'Admin123!';

GRANT SELECT,INSERT,UPDATE,DELETE ON bd_MussiteDatabase.* TO 'admin'@'localhost';

