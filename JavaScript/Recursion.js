function powerOf(x, n) {
    // if (n === 1) {
    //   return x;
    // }
    // return x * powerOf(x, n - 1);
    return n === 1 ? x : x * powerOf(x, n - 1);
}

console.log(powerOf(2, 3)); // 2 * 2 * 2

const myself = {
    name: 'Max',
    friends: [
        {
            name: 'Manuel',
            friends: [
                {
                    name: 'Chris',
                    friends: [
                        {
                            name: 'Hari'
                        },
                        {
                            name: 'Amilia'
                        }
                    ]
                }
            ]
        },
        {
            name: 'Julia'
        }
    ]
};

function getFriendNames(person) {
    const collectedNames = [];
    if (!person.friends) {
        return [];
    }
    for (const friend of person.friends) {
        collectedNames.push(friend.name);
        collectedNames.push(...getFriendNames(friend));
    }
    return collectedNames;
}

console.log(getFriendNames(myself));