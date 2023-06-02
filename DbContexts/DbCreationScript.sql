DROP TABLE IF EXISTS orders CASCADE;
CREATE TABLE orders
(
    id serial PRIMARY KEY,
    sender_city varchar(32) NOT NULL,
	sender_address varchar(64) NOT NULL,
	recipient_city varchar(32) NOT NULL,
	recipient_address varchar(64) NOT NULL,
	cargo_weight NUMERIC(6,3) NOT NULL,
    pickup_date timestamp NOT NULL
);

INSERT INTO orders(sender_city, sender_address, recipient_city, recipient_address, cargo_weight, pickup_date)
VALUES
('Москва', 'ул. Есенина, д. 20, кв. 8', 'Новосибирск', 'пер. Ашхабадский, д. 40', 23.3, CURRENT_TIMESTAMP),
('Санкт-Петербург', 'пр-кт Науки, д. 100, кв. 89', 'Ростов-на-Дону', 'ул. Таганрогская, д. 50, к. 1, кв. 70', 100.677, CURRENT_TIMESTAMP);

SELECT * FROM orders