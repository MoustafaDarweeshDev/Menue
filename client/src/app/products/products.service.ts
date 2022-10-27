import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { IItem ,IItemWithImage} from '../Interfaces/Item';
import { IBasket } from '../Interfaces/basket';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { IProduct } from '../Interfaces/products';


@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl = environment.apiUrl;
  basket = new BehaviorSubject<IBasket | null>(null)

  constructor(private http:HttpClient) { }



  getAllItems(){
    return this.http.get<IItem[]>(this.baseUrl+'home/GetAllItems')
  }

  deleteItemById(id:any){
    return this.http.delete<IItem>(this.baseUrl+`home/DeleteItemById?id=${id}`)
  }

  AddItem(item:IItem){
    return this.http.post<IItem>(this.baseUrl+'home/Add',item)
  }

  updateItem(item:IItem , id:number){
    return this.http.put<IItem>(this.baseUrl + `home/UpdateItem?id=${id}`,item)

  }
  uploadImaage(file:File):Observable<IItemWithImage>{
    var formData = new FormData();
    formData.append('img',file)
    return this.http.post<IItemWithImage>(this.baseUrl+'home/Upload' , formData)
  }

  // basket actions

  createBasket(){
    return this.http.get(this.baseUrl + 'home/CreateBasket')
  }

  addItemToCart( basketId:string ,item:IItem ){
    return this.http.post<IBasket>(this.baseUrl + 'home/addItemToBasket?id='+basketId , item)
  }
  getBasketById(id:string){
    return this.http.get<IBasket>(this.baseUrl + 'home/getBasketById?id='+id)

  }
  removeFromBasket( basketId:string ,itemId:number ){
    return this.http.get<IBasket>(this.baseUrl + `home/RemoveFromBasket?basketId=${basketId}&itemId=${itemId}`)
  }

  //product page
  getProducts(){
    return this.http.get<IProduct[]>(this.baseUrl+'home/GetAllPrices')
  }


  //
  private subject = new Subject<any>();
  sendClickEvent() {
  this.subject.next('s');
  }
  getClickEvent(): Observable<any>{
    return this.subject.asObservable();
  }



}
