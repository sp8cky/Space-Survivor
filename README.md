# Space-Survivor

This project is a simple implementation of the classic arcade game Space Invaders using Unity, see [Project Status](#project-status) for more information.

## Table of Contents

1. [Implemented Features](#Implemented-Features)
2. [Installation](#installation)
3. [Contributing](#contributing)
4. [License](#license)
5. [Credits](#credits)
6. [Acknowledgments](#acknowledgments)


## Implemented Features:
- Player movement: Control the player character using the left and right arrow keys.
- Player shooting: Press the spacebar to shoot bullets and destroy enemy invaders.
- Enemy invaders: Enemy units move horizontally and descend gradually towards the player. 
- Score system: Players earn points by shooting down enemy invaders. The current score is displayed on the screen.
- Health system: Players start with a certain amount of health. Player can gain and loose health to collision with items or enemies and when health reaches zero, the game ends.


### Project status
- Still in progress

### Future implementations
- new Enemy-Types, attacks
- Better UI
- ...

## Installation

### Prerequisites and important info

- Unity Version: This project was developed using Unity LTS version 2022.3.26f1.
- Compatibility: The game is designed for 2D gameplay and is compatible with desktop platforms.


### Installation Steps
Clone the repository and add it to Unity Hub
```bash
git clone https://github.com/sp8cky/Space-Survivor
```

### Customization Options:
- Code Structure: The project follows a modular code structure, making it easy to understand and extend. Scripts are organized into logical components such as PlayerController, EnemyController, and GameManager.
- Adjust player movement speed: Players can tweak the movement speed of the player character in the PlayerController script.
- Modify enemy behavior: Users can customize various aspects of the enemy behavior, such as movement speed, spawn rate, and attack patterns, by adjusting parameters in the EnemyController script.
- Change game visuals: Users can replace the default sprites with their own artwork to customize the game's appearance.

## Contributing
- Feedback and contributions are welcome! If you encounter any issues or have suggestions for improvements, feel free to open an issue or submit a pull request on GitHub.

### How to Contribute
1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin feature/your-feature`
5. Open a pull request

## License:
- This project is licensed under the MIT-License. See the LICENSE file for details.

## Credits:
- This project was created by sp8cky.

## Acknowledgments
- I used the following packages and assets, thanks for those packages!
- Galaxia 2D Space Shooter Sprite Pack #1 by Josh Marshall (https://assetstore.unity.com/packages/2d/textures-materials/galaxia-2d-space-shooter-sprite-pack-1-64944)
- Dynamic Space Background Lite by DinV Studio (https://assetstore.unity.com/packages/2d/textures-materials/dynamic-space-background-lite-104606)

