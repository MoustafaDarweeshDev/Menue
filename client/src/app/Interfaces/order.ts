import { IItem } from "./Item";

export interface IOrder {
  customerName: string;
  customerPhone: string;
  total: number;
  orderDate: Date;
  items: IItem[];
  id: number;
}
