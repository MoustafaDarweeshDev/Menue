import { Component, OnInit } from '@angular/core';
import { IItem } from '../Interfaces/Item';
import { IProduct } from '../Interfaces/products';
import { ProductsService } from './products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  allItems:IItem[]=[];
  allProducts:IProduct[]
  constructor(private productService:ProductsService) { }

  ngOnInit(): void {
    this.getAllProducts();
  }

  getAllProducts(){
    this.productService.getProducts().subscribe(res=>{
      this.allProducts=res
      console.log('prices' ,res);

    },err=>{
      console.log(err);

    })
  }


  addTobasket(itemId:number,priceId:number ){
    var basketId = localStorage.getItem('basket_Id');
    if(basketId){
      this.productService.addItemToCart(basketId , itemId ,priceId).subscribe(res=>{
        this.productService.basket.next(res)
        this.productService.sendClickEvent();
      },err=>{
        console.log(err);
      })
    }
  }

}
