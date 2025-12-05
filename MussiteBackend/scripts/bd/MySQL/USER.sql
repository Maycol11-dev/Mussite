
USE 5to_mussitedatabase

DROP USER IF EXISTS 'admin'@'localhost';
CREATE USER 'admin'@'localhost' IDENTIFIED BY 'Admin123!';
GRANT SELECT,INSERT,UPDATE,DELETE ON 5to_mussitedatabase.* TO 'admin'@'localhost';

