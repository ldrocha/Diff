## The assignment
• Provide 2 http endpoints that accepts JSON base64 encoded binary data on both Endpoints:
```
<host>/v1/diff/<ID>/left
<host>/v1/diff/<ID>/right
```
• The provided data needs to be diff-ed and the results shall be available on a third Endpoint:
```
<host>/v1/diff/<ID>
```
• The results shall provide the following info in JSON format:
- If equal return that
- If not of equal size just return that
- If of same size provide insight in where the diffs are, actual diffs are not needed (so mainly offsets + length in the data)
- Make assumptions in the implementation explicit, choices are good but need to be communicated

### Must haves
- Solution written in C#
- Internal logic shall be under unit test
- Functionality shall be under integration test • Documentation in code
- Clear and to the point readme on usage

### Nice to haves
• Suggestions for improvement

# Diff Solution

The solution was developed in .Net 6 https://dotnet.microsoft.com/en-us/download/dotnet/6.0.

This solution has:

- SOLID
- Layered Architecture
- .Net 6
- C#
- Swagger with documentation and prepared to send requests
- API versioning 
- EF Core
- Data Seeding
- HttpLogging middleware
- AutoMapper
- Unity and integration tests in Xunit
- FluentAssertions
- AutoFixture
- NSubstitute

Once running, it can be accessed at https://localhost:7185/swagger/index.html, in this page is the documentation and it's possible to send requests.

## Using

The 2 http endpoints that accepts JSON base64 encoded binary data are:

```
curl -X 'PUT' \
  'https://localhost:7185/v1/diff/11/left' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "data": "aGVsbG8gd29ybGQgISEh"
}'

RESPONSE
[201] Created
{
  "id": "11",
  "data": "aGVsbG8gd29ybGQgISEh"
}

[400] Bad Request
Bad Request status will be retuned when the string is not a valid base64 encoded binary
```

```
curl -X 'PUT' \
  'https://localhost:7185/v1/diff/11/right' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "data": "aGVsbG8gd29ybGQgISEh"
}'

RESPONSE
[201] Created
{
  "id": "11",
  "data": "aGVsbG8gd29ybGQgISEh"
}

[400] Bad Request
Bad Request status will be retuned when the string is not a valid base64 encoded binary
```

The third Endpoint where the provided data needs to be diff-ed and result should be returned is:

```
curl -X 'GET' \
  'https://localhost:7185/v1/diff/11' \
  -H 'accept: text/plain'
  
RESPONSE
[200] Ok
{
  "id": "11",
  "status": "Equal",
  "detail": null
}

[200] Ok
{
  "id": "456",
  "status": "DifferentLength",
  "detail": null
}

[200] Ok
{
  "id": "789",
  "status": "SameLength",
  "detail": {
    "lenght": 28,
    "offsetLenght": 6,
    "differencesOffsets": [
      8,
      9,
      10,
      16,
      17,
      18
    ]
  }
}

[404] Not Found
Not Found status will be return when one or both items compared do not exist
```
## Suggestions for improvement

- Switch from InMemoryDatabase to a traditional database
- Implement cache
- Containerize the application with Docker
