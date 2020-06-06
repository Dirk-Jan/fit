# spekkie
Oauth identity service for securing applications

# Environment variables
|Variable name|Allowed data|Default value|Required|Info|
|:-|:-|:-|-|-|
|REGISTER_ENABLED|true / false|false|❌|-|
|DB_CONNECTION_STRING|-|-|✔️|-|
|CONFIG_PATH_CLIENTS|-|-|✔️|-|
|CONFIG_PATH_IDS|-|-|✔️|-|
|CONFIG_PATH_APIS|-|-|✔️|-|
|PUBLIC_ORIGIN|-|-|✔️|The public URL of the identity server (Required for TLS)| 
|REGISTER_REDIRECT_URL|-|-|✔️|-|
|ADMIN_USERNAME|-|admin|❌|-|
|ADMIN_PASSWORD|-|Pass123$|❌|-|
