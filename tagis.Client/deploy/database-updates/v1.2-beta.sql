USE tagis;

ALTER TABLE company ADD COLUMN discount VARCHAR(1000);
ALTER TABLE company ADD COLUMN coupon_code VARCHAR(1000);

ALTER TABLE orders ADD COLUMN coupon_email_sent TIMESTAMP;
ALTER TABLE orders ADD COLUMN coupon_email_id VARCHAR(1000);
ALTER TABLE orders ADD COLUMN order_notification_sent TIMESTAMP;
ALTER TABLE orders ADD COLUMN order_notification_id VARCHAR(1000);
ALTER TABLE orders MODIFY created_date DATETIME;
ALTER TABLE orders MODIFY last_modified_date DATETIME;