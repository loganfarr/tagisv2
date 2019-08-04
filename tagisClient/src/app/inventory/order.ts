import { Product } from './product';

export class Order {
  _oid: number;
  order_status: string = '';
  created_date: string = '';
  last_modified_date: string = '';
  products: Array<Product>;
  subtotal: number;
  taxes: number;
  total: number;
  company: Object;
  company_title: string = '';
  logo: string; // Company logo
  customer_name: string = '';
  customer_email: string = '';
  customer_phone: string = '';
  customer_address1: string = '';
  customer_address2: string = '';
  customer_city: string = '';
  customer_state: string = '';
  customer_zip: string = '';
  shipping_name: string = '';
  shipping_address1: string = '';
  shipping_address2: string = '';
  shipping_city: string = '';
  shipping_state: string = '';
  shipping_zip: string = '';
  order_source: string = '';
  ref: string = '';
  shipping_number: string = '';
  shipping_carrier: string = '';
  send_order_receipt: Boolean;
  receipt_email_sent: Date;
  send_shipping_notification: Boolean;
  shipping_email_sent: Date;
}
