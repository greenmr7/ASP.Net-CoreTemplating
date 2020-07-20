# APICore

## Use tooltip
```javascript
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
```


## data Divisions:

```json
[
    {
        "id": 2,
        "name": "jkl",
        "departmentId": 0,
        "departmentName": "jodi"
    }
]
```

### Url to use API:

- Get ALL: `https://{Your Host}:{Your Port}/api/divisions`
- Get Id: `https://{Your Host}:{Your Port}/api/divisions/{id}`
- Post: `https://{Your Host}:{Your Port}/api/divisions`
- Put: `https://{Your Host}:{Your Port}/api/divisions/{id}`
- Delete: `https://{Your Host}:{Your Port}/api/divisions/{id}`

## data Department:

```json
[
    {
        "id": 2,
        "name": "jodi",
    }
]
```

### Url to use API:

- Get ALL: `https://{Your Host}:{Your Port}/api/Departments`
- Get Id: `https://{Your Host}:{Your Port}/api/Departments/{id}`
- Post: `https://{Your Host}:{Your Port}/api/Departments`
- Put: `https://{Your Host}:{Your Port}/api/Departments/{id}`
- Delete: `https://{Your Host}:{Your Port}/api/Departments/{id}`
