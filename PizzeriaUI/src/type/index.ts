export interface Topping {
  id: number;
  name: string;
  price: number;
}

export interface MenuItemType {
  id: number;
  pizzeriaId: number;
  pizzaId: number;
  price?: number;
  pizzaName: string;
  toppings: Array<Topping>;
}

export interface MenuItemTypeInOrder extends Partial<MenuItemType> {
  orderId: string;
}
