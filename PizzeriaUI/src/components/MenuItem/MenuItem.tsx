import React, { useState } from "react";
import { Card, Col, Button } from "antd";
import { MenuItemType, Topping, MenuItemTypeInOrder } from "../../type";
import { getUniqueId } from "../../utils/getUniqueId";
import useOrderContext from "../../hook/useOrderContext";

interface MenuItemProps {
  id: number;
  pizzaName: string;
  price?: number;
  toppings: Array<Topping>;
}

export const MenuItem: React.FC<MenuItemProps> = ({
  id,
  pizzaName,
  price,
  toppings,
}) => {
  const initCurrentOrderItem: Partial<MenuItemType> = {
    id,
    pizzaName,
    price,
    toppings: [],
  };
  const orderState = useOrderContext();
  const [currentOrderItem, setCurrentOrderItem] =
    useState<Partial<MenuItemType>>(initCurrentOrderItem);
  const addOrderHandler = () => {
    const itemInOrder: MenuItemTypeInOrder = {
      ...currentOrderItem,
      orderId: getUniqueId(),
    };
    orderState?.updateCurrentOrder([...orderState.currentOrder, itemInOrder]);
  };

  const handleToppingCheckboxChange = (
    topping: Topping,
    isChecked: boolean
  ) => {
    if (isChecked) {
      const update = {
        ...currentOrderItem,
        toppings: [...(currentOrderItem.toppings as Array<Topping>), topping],
      };
      console.log("checkbox update", update);
      setCurrentOrderItem(update);
    } else {
      const updateToppings = currentOrderItem.toppings?.filter(
        (t) => t.id !== topping.id
      );
      const update = {
        ...currentOrderItem,
        toppings: updateToppings,
      };
      console.log("update", update);
      setCurrentOrderItem(update);
    }
  };

  return (
    <>
      <Col span={8}>
        <Card title={pizzaName} style={{ width: 300 }}>
          <p>${price}</p>
          <p>
            Toppings:
            <ul>
              {toppings.map((t) => (
                <li>
                  <input
                    type="checkbox"
                    onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                      handleToppingCheckboxChange(t, e.target.checked)
                    }
                  />{" "}
                  {t.name}: ${t.price}
                </li>
              ))}
            </ul>
          </p>
          <Button onClick={addOrderHandler}>Add to Order</Button>
        </Card>
      </Col>
    </>
  );
};
