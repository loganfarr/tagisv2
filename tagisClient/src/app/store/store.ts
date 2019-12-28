export class Store {
  _cid: number;
  title: string = '';
  machine_name: string = '';
  logo: string = '';
  address1: string = '';
  address2: string = '';
  city: string = '';
  state: string = '';
  zip: string = '';
  contact_name: string = '';
  contact_email: string = '';
  contact_phone: string = '';
  websiteUrl: string = '';
  storeUrl: string = '';
  product_api_endpoint: string = '';
  order_api_endpoint: string = '';
  auth_token: string = '';
  emails_enabled: boolean = false;
  email_from_address: string = '';
  receipt_email: number;
  shipping_notification_email: number;
  thank_you_email: number;
  discount: string = '';
  coupon_code: string = '';
}
