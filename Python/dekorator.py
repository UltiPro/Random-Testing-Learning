def todo(func):
    def wrapper():
        return func().upper()
    return wrapper

@todo
def foo():
    return "bar"

print(todo())
