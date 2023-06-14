import React from 'react';
import {Menu, Layout as AntdLayout, theme, Dropdown, Button, Statistic, Space} from "antd";
import {useAuth} from "../../hooks/useAuth";
import {useUser} from "../../hooks/useUser";
import {DollarOutlined} from "@ant-design/icons";

const { Header, Content, Footer } = AntdLayout;

function UserOutlined() {
    return null;
}

const Layout = ({children}) =>  {
  const {
      token: { colorBgLayout },
  } = theme.useToken();
    const { logout } = useAuth();
    const { user } = useUser();

    const userMenuItems = [
        {
            key: 'my-profile',
            label: 'My profile',
            //onClick: handleManageUsersClick
        },
        {
            key: 'logout',
            label: 'Logout',
            onClick: () => logout()
        },
    ]

    const navMenuItems = [
        {key: "catalog", label: "Catalog"}
    ]

  return (
      <AntdLayout theme="light" style={{ minHeight: '100vh' }}>
          <Header
              className='d-flex-space-between'
              style={{
                  backgroundColor: '#fff',
                  boxShadow: '0 1px 4px rgba(0, 21, 41, 0.08)',
                  width: '100%',
              }}
          >
              <Menu
                  theme="light"
                  mode="horizontal"
                  items={navMenuItems}
              />
              <Space size={16}>
                <Statistic title="Balance" value={user.rentPrice} prefix='$' />
                <Dropdown
                    menu={{items: userMenuItems}}
                    overlayStyle={{minWidth: 180}}
                >
                    <Button type="text" size='large'>
                        <UserOutlined /> {user?.name}
                    </Button>
                </Dropdown>
              </Space>
          </Header>
          <Content
              style={{
                  padding: '24px 48px',
              }}
          >
              <div
                  className="site-layout-content"
                  style={{
                      background: colorBgLayout,
                  }}
              >
                  {children}
              </div>
          </Content>
          <Footer
              style={{
                  textAlign: 'center',
              }}
          >
              Library
          </Footer>
      </AntdLayout>
  )
}
export default Layout;
