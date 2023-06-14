import React from 'react';
import {Menu, Layout as AntdLayout, theme, Dropdown, Button} from "antd";
import {useAuth} from "../../hooks/useAuth";

const { Header, Content, Footer } = AntdLayout;

function UserOutlined() {
    return null;
}

const Layout = ({children}) =>  {
  const {
      token: { colorBgLayout },
  } = theme.useToken();
    const { logout } = useAuth();


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
              <Dropdown
                  menu={{items: userMenuItems}}
                  overlayStyle={{minWidth: 180}}
              >
                  <Button type="text" size='large'>
                      <UserOutlined /> Nazar
                  </Button>
              </Dropdown>
          </Header>
          <Content
              style={{
                  padding: '0 50px',
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
              Ant Design ©2023 Created by Ant UED
          </Footer>
      </AntdLayout>
  )
}
export default Layout;
