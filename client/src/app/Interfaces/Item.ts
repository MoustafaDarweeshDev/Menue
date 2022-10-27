
export interface IItem {
  name: string;
  price: number;
  imageUrl: string;
  prices: IPrices[];
  id: number;
}
export interface IPrices {
  sizeName: string;
  sizePrice: string;
}

export interface IItemWithImage {
url:string
}
