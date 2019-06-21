export default [
    {
        path: '/signin-callback-oidc',
        component: './oidc/SigninCallback'
    },
    {
        path: '/user',
        component: '../layouts/UserLayout',
        routes: [
            {
                path: '/user/login',
                component: './user/Login'
            }
        ]
    },
    {
        path: '/',
        component: '../layouts/BasicLayout',
        Routes: ['src/pages/Authorized'],
        authority: ['admin'],
        routes: [
            {
                path: '/',
                name: 'welcome',
                icon: 'smile',
                component: './Welcome',
            },
            {
                path: '/clients',
                name: 'clients',
                icon: 'desktop',
                component: '../layouts/BlankLayout',
                hideChildrenInMenu: true,
                routes: [
                    {
                        path: '/clients',
                        component: './clients/List'
                    },
                    {
                        path: '/clients/add',
                        component: './clients/AddClient'
                    },
                    {
                        path: '/clients/edit',
                        component: './clients/EditClient'
                    }
                ]
            },

        ],
    },
]
