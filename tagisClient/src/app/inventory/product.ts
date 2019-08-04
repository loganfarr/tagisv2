export class Product {
    _pid: number;
    sku: string;
    product_title: string;
    stock: number;
    quantity: number;
    company: number;
    status: boolean;
    _cid:number = this.company;
    company_title: string;
    image: string;
    logo: string; // Company logo
    description: string;
    price: number;
    cost: number;
    store_id: number;
}