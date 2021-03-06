export default [
    {
        path: '/signin-callback-oidc',
        component: './oidc/SigninCallback',
    },
    {
        path: '/silent-refresh',
        component: './oidc/SilentRefresh',
    },
    {
        path: '/user',
        component: '../layouts/UserLayout',
        routes: [
            {
                path: '/user/login',
                component: './user/Login',
            },
        ],
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
                        component: './clients/List',
                    },
                    {
                        path: '/clients/add',
                        component: './clients/AddClient',
                    },
                    {
                        path: '/clients/edit/:id',
                        component: './clients/EditClient',
                    },
                    {
                        path: '/clients/:id/secrets',
                        component: './clients/Secrets',
                    },
                    {
                        path: '/clients/:id/properties',
                        component: './clients/Properties',
                    },
                    {
                        path: '/clients/:id/claims',
                        component: './clients/Claims',
                    },
                ],
            },
            {
                path: '/users',
                name: 'users',
                icon: 'user',
                component: '../layouts/BlankLayout',
                hideChildrenInMenu: true,
                routes: [
                    {
                        path: '/users',
                        component: './users/List'
                    },
                    {
                        path: '/users/:id',
                        component: './users/Edit'
                    }
                ]
            }
        ],
    },
];
