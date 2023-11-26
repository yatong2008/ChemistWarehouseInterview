import { useEffect, useState } from "react";
import { Card, Typography, Button } from "antd";
import { calculateTotalPrice } from "../../utils/calculate";
import useOrderContext from "../../hook/useOrderContext";

const { Title } = Typography;

export const OrderDetails = () => {
  const orderState = useOrderContext();
  const [totalPrice, setTotalPrice] = useState<number>(0);

  useEffect(() => {
    console.log("current", orderState?.currentOrder);
    setTotalPrice(calculateTotalPrice(orderState?.currentOrder));
  }, [orderState?.currentOrder]);

  const removeHandler = (id: string) => {
    const update = orderState?.currentOrder.filter((e) => e.orderId !== id);
    if (update) {
      orderState?.updateCurrentOrder(update);
    }
  };

  const submitOrder = () => {
    const submit = async () => {
      try {
        const responses = await fetch("https://localhost:7078/api/Order", {
          method: "POST",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            orderItems: orderState?.currentOrder,
            totalPrice: 0,
          }),
        });
        const data = await responses.json();
      } catch (e: any) {
        console.error(e.message);
      }
    };
    submit();
  };

  return (
    <>
      <Card title="Order Details">
        {orderState?.currentOrder &&
          orderState?.currentOrder.map((element) => {
            return (
              <>
                <Card
                  style={{ marginTop: 16 }}
                  type="inner"
                  title={element.pizzaName}
                >
                  <Title level={5}>$ {element.price}</Title>
                  <Title level={5}>Toppings:</Title>
                  <ul>
                    {element.toppings?.map((t) => {
                      return (
                        <li>
                          {t.name} ${t.price}
                        </li>
                      );
                    })}
                  </ul>
                  <Button onClick={() => removeHandler(element.orderId)}>
                    Delete
                  </Button>
                </Card>
              </>
            );
          })}

        <Title level={3}>Total Price: ${totalPrice}</Title>

        <Button onClick={submitOrder}>Finish Order</Button>
      </Card>
    </>
  );
};
