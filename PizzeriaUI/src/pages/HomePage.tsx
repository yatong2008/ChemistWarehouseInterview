import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Typography } from "antd";
import { Card, Row, Col } from "antd";
import styles from "./HomePage.module.css";

const { Title } = Typography;
const { Meta } = Card;

export const HomePage = () => {
  const [pizzerias, setPizzerias] = useState<any>([]);
  const [error, setError] = useState<string>();
  const navigate = useNavigate();

  const onPizzeriaSelected = (id: string) => {
    navigate(`pizzerias/${id}`);
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const responses = await fetch("https://localhost:7078/api/Pizzerias");
        const data = await responses.json();
        setPizzerias(data);
      } catch (e: any) {
        setError(e.message);
      }
    };

    fetchData();
  }, [setPizzerias, setError]);

  return (
    <>
      {!error || (error !== "" && <div>Error: {error}</div>)}

      <Title level={2}>
        Welcome to Pizzeria, please select which shop you want to order from:
      </Title>
      <br />
      <Row>
        {pizzerias.map((p: any) => (
          <Col span={8}>
            <Card
              className={styles["pizzeria-card-class"]}
              hoverable
              title={p.name}
              style={{ width: 300 }}
              cover={<img alt="example" src={p.imageUrl} />}
              onClick={() => onPizzeriaSelected(p.id)}
            >
              <Meta
                title={`${p.name}`}
                description={`Order best pizza in ${p.name}`}
              />
            </Card>
            <br />
          </Col>
        ))}
      </Row>
    </>
  );
};
