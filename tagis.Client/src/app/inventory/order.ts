import { Product } from './product';
import {Store} from "../store/store";

export class Order {
  _oid: number;
  orderStatus: string = '';
  createdDate: string = '';
  lastModifiedDate: string = '';
  products: Array<Product>;
  subtotal: number;
  taxes: number;
  total: number;
  store: Store;
  logo: string; // Store logo
  customerName: string = '';
  customerEmail: string = '';
  customerPhone: string = '';
  customerAddress1: string = '';
  customerAddress2: string = '';
  customerCity: string = '';
  customerState: string = '';
  customerZip: string = '';
  shippingName: string = '';
  shippingAddress1: string = '';
  shippingAddress2: string = '';
  shippingCity: string = '';
  shippingState: string = '';
  shippingZip: string = '';
  orderSource: string = '';
  ref: string = '';
  shippingNumber: string = '';
  shippingCarrier: string = '';
  sendOrderReceipt: Boolean;
  receiptEmailSent: Date;
  sendShippingNotification: Boolean;
  shipping_email_sent: Date;
}
