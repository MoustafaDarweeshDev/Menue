import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IOrder } from '../Interfaces/order';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  apiUrl = environment.apiUrl
  constructor(private httpClient:HttpClient) { }

  getAllOrders(){
    return this.httpClient.get<IOrder[]>(this.apiUrl+'Orders/GetAllOrders');
  }

  createOrder(orderToCreate:IOrder){
    return this.httpClient.post<IOrder>(this.apiUrl +'orders/PlaceOrder',orderToCreate)
  }
  placeOrder(basketId:string , custNaame:string,custPhone:string){
    return this.httpClient.post<IOrder>(this.apiUrl +`orders/PlaceOrder?basketId=${basketId}&custName=${custNaame}&cusPhone=${custPhone}`,{})
  }
}
