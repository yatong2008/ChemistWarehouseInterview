import { useContext } from "react";
import OrderContext, { OrderContextInterface } from "../context/OrderContext";

const useOrderContext = () => {
  const orderState = useContext<OrderContextInterface | null>(OrderContext);
  return orderState;
};

export default useOrderContext;
