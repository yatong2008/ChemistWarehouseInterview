import { MenuItemTypeInOrder } from "../type";

export const calculateTotalPrice = (
  items?: Array<MenuItemTypeInOrder>
): number => {
  if (items) {
    let total = 0;

    for (const item of items) {
      total += item.price !== undefined ? item.price : 0;
      for (const topping of item.toppings || []) {
        total += topping.price;
      }
    }

    return total;
  }
  return 0;
};
