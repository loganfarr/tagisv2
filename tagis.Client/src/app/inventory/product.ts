export class Product {
    _pid: number;
    sku: string;
    product_title: string;
    stock: number;
    quantity: number;
    store: number;
    status: boolean;
    _cid:number = this.store;
    store_title: string;
    image: string;
    logo: string; // Store logo
    description: string;
    price: number;
    cost: number;
    store_id: number;
}
