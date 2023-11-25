import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Layout, Row, Button, Typography } from "antd";
import MenuItem from "../components/MenuItem";
import { useParams } from "react-router-dom";
import { OrderDetails } from "../components/OrderDetails/OrderDetails";
import { MenuItemType } from "../type";
const { Sider, Content } = Layout;
const { Title } = Typography;

export const MenuPage = () => {
  const [menuItems, setMenuItems] = useState<Array<MenuItemType>>([]);
  const [error, setError] = useState<string>();
  const { id } = useParams();
  const navigate = useNavigate();

  const backToHome = () => {
    navigate("/");
  };

  useEffect(() => {
    const fetchData = async (pizzeriaId: string) => {
      try {
        const responses = await fetch(
          `https://localhost:7078/api/Pizzerias/${pizzeriaId}/MenuItems`
        );
        const data = await responses.json();
        setMenuItems(data);
      } catch (e: any) {
        setError(e.message);
      }
    };

    fetchData(id as string);
  }, []);

  return (
    <>
      {!error || (error !== "" && <div>Error: {error}</div>)}

      <Title level={5}>Please add Pizza to Cart:</Title>

      <Layout>
        <Layout>
          <Content>
            <Row gutter={16}>
              {menuItems.map((m) => (
                <MenuItem
                  id={m.id}
                  pizzaName={m.pizzaName}
                  price={m.price}
                  toppings={m.toppings}
                />
              ))}
            </Row>
          </Content>
        </Layout>
        <Sider style={{ backgroundColor: "#FFFFFF" }}>
          <OrderDetails />
        </Sider>
      </Layout>
      <Button onClick={backToHome}>Back</Button>
    </>
  );
};
