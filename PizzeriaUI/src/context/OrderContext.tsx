import { createContext, useState, ReactNode, useEffect } from "react";
import { MenuItemType, MenuItemTypeInOrder } from "../type";

export interface OrderContextInterface {
  currentOrder: Array<MenuItemTypeInOrder>;
  updateCurrentOrder: (value: Array<MenuItemTypeInOrder>) => void;
}

interface OwnProps {
  children: ReactNode;
}

const Context = createContext<OrderContextInterface | null>(null);

export const OrderStore: React.FC<OwnProps> = ({ children }: OwnProps) => {
  const [currentOrder, updateCurrentOrder] = useState<
    Array<MenuItemTypeInOrder>
  >([]);
  return (
    <Context.Provider value={{ currentOrder, updateCurrentOrder }}>
      {children}
    </Context.Provider>
  );
};

export default Context;
