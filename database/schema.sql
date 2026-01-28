-- ===============================
-- DATABASE
-- ===============================
CREATE DATABASE IF NOT EXISTS stratus_app_db;
USE stratus_app_db;

-- ===============================
-- CLIENT
-- ===============================
CREATE TABLE client (
  client_id INT AUTO_INCREMENT PRIMARY KEY,
  client_name VARCHAR(100) NOT NULL
);

-- ===============================
-- LOCATION
-- ===============================
CREATE TABLE location (
  location_id INT AUTO_INCREMENT PRIMARY KEY,
  client_id INT NOT NULL,
  location_name VARCHAR(100) NOT NULL,
  wifi_name VARCHAR(100),
  username VARCHAR(100),
  password VARCHAR(255), -- hashed passwords only
  otp VARCHAR(6),
  FOREIGN KEY (client_id) REFERENCES client(client_id)
);

-- ===============================
-- DEVICE TYPES
-- ===============================
CREATE TABLE dev_type (
  device_type VARCHAR(20) PRIMARY KEY,
  device_name VARCHAR(50) NOT NULL
);

-- ===============================
-- DEVICES
-- ===============================
CREATE TABLE device (
  device_id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100),
  mac VARCHAR(50) NOT NULL,
  device_type VARCHAR(20) NOT NULL,
  location_id INT NOT NULL,
  FOREIGN KEY (device_type) REFERENCES dev_type(device_type),
  FOREIGN KEY (location_id) REFERENCES location(location_id)
);

-- ===============================
-- CONTENT
-- ===============================
CREATE TABLE content (
  content_id INT AUTO_INCREMENT PRIMARY KEY,
  file_name VARCHAR(255) NOT NULL,
  length_seconds INT,
  description VARCHAR(255)
);

-- ===============================
-- CATEGORY
-- ===============================
CREATE TABLE category (
  cat_id INT AUTO_INCREMENT PRIMARY KEY,
  cat_name VARCHAR(50) NOT NULL
);

-- ===============================
-- CONTENT ↔ CATEGORY
-- ===============================
CREATE TABLE content_cat (
  cc_id INT AUTO_INCREMENT PRIMARY KEY,
  content_id INT NOT NULL,
  cat_id INT NOT NULL,
  FOREIGN KEY (content_id) REFERENCES content(content_id),
  FOREIGN KEY (cat_id) REFERENCES category(cat_id)
);

-- ===============================
-- SHOW (RENAMED FOR SAFETY)
-- ===============================
CREATE TABLE signage_show (
  show_id INT AUTO_INCREMENT PRIMARY KEY,
  content_id INT NOT NULL,
  device_id INT NOT NULL,
  location_id INT NOT NULL,
  client_id INT NOT NULL,
  start DATETIME NOT NULL,
  finish DATETIME NOT NULL,
  FOREIGN KEY (content_id) REFERENCES content(content_id),
  FOREIGN KEY (device_id) REFERENCES device(device_id),
  FOREIGN KEY (location_id) REFERENCES location(location_id),
  FOREIGN KEY (client_id) REFERENCES client(client_id)
);

-- ===============================
-- SLIDES (USED BY YOUR EDITOR + API)
-- ===============================
CREATE TABLE Slides (
  SlideId INT AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(255) NOT NULL,
  Html LONGTEXT NOT NULL,
  ScheduleStart DATETIME NULL,
  ScheduleEnd DATETIME NULL,
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- ===============================
-- INDEXES (PERFORMANCE)
-- ===============================
CREATE INDEX idx_device_location ON device(location_id);
CREATE INDEX idx_show_device ON signage_show(device_id);
CREATE INDEX idx_slide_schedule ON Slides(ScheduleStart, ScheduleEnd);
