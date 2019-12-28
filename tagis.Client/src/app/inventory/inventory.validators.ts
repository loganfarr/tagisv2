import { FormControl } from '@angular/forms';

import { Product } from './product';
import { ProductService } from './product.service';

export class InventoryValidators {
  static validateSku(sku: string, list: Array<Product>) {
    if(sku != undefined && list != undefined) {
      for (var i = 0; i < list.length; ++i) {
        console.log(sku, list[i].sku);
        if(sku == list[i].sku)
          return null;
      }

      return { validSku: true }
    }
  }

  static skuExists(sku: string, list: Array<Product>) {
    var result = this.validateSku(sku, list);

    // If validateSkuWithList returns null, the SKU exists
    if(result == null) 
      return true;
    else
      return false;
  }
}