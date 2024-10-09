
CREATE DATABASE AssetManagement;


CREATE TABLE Employees
(
    employee_id INT PRIMARY KEY,
    name VARCHAR(100),
    department VARCHAR(100),
    email VARCHAR(100),
    password VARCHAR(100)
);

CREATE TABLE Assets
(
    asset_id INT PRIMARY KEY,
    name VARCHAR(100),
    type VARCHAR(100),
    serial_number VARCHAR(100),
    purchase_date DATE,
    location VARCHAR(100),
    status VARCHAR(100),
    owner_id INT,
    FOREIGN KEY (owner_id) REFERENCES Employees(employee_id)
);

CREATE TABLE MaintenanceRecords
(
    maintenance_id INT PRIMARY KEY,
    asset_id INT,
    maintenance_date DATE,
    description VARCHAR(255),
    cost DECIMAL(10, 2),
    FOREIGN KEY (asset_id) REFERENCES Assets(asset_id)
);

CREATE TABLE AssetAllocations
(
    allocation_id INT PRIMARY KEY,
    asset_id INT,
    employee_id INT,
    allocation_date DATE,
    return_date DATE,
    FOREIGN KEY (asset_id) REFERENCES Assets(asset_id),
    FOREIGN KEY (employee_id) REFERENCES Employees(employee_id)
);

CREATE TABLE Reservations
(
    reservation_id INT PRIMARY KEY,
    asset_id INT,
    employee_id INT,
    reservation_date DATE,
    start_date DATE,
    end_date DATE,
    status VARCHAR(100),
    FOREIGN KEY (asset_id) REFERENCES Assets(asset_id),
    FOREIGN KEY (employee_id) REFERENCES Employees(employee_id)
);

 