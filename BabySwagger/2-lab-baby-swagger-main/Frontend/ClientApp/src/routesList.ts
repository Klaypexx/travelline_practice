export type HttpMethod = 'GET' | 'POST' | 'PUT' | 'DELETE';

export type RouteType = {
  method: HttpMethod;
  path: string;
  id: string;
  parameters?: { [key: string]: string };
  body?: { [key: string]: string | number };
}


export const routesList: RouteType[] = [
    {
      method: 'GET',
      path: '/Users',
      id: 'get-all-block'
    },
    {
      method: 'POST',
      path: '/Users',
      id: 'post-block',
      body: {
        firstName: 'string',
        lastName: 'string',
        email: 'user@example.com',
        role: 1
      }
    },
    {
      method: 'GET',
      path: '/Users/{id}',
      id: 'get-by-id-block',
      parameters: { id: 'integer' }
    },
    {
      method: 'PUT',
      path: '/Users/{id}',
      id: 'put-block',
      parameters: { id: 'integer' },
      body: {
        firstName: 'string',
        lastName: 'string',
        role: 1
      }
    },
    {
      method: 'DELETE',
      path: '/Users/{id}',
      id: 'delete-block',
      parameters: { id: 'integer' }
    },
    {
      method: 'GET',
      path: '/Users/get-by-email/{email}',
      id: 'get-by-email-block',
      parameters: { email: 'string' }
    },
    
  ];